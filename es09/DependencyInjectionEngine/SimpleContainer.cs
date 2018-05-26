using System;
using System.Reflection;
using System.Collections.Generic;

namespace simplecontainer
{
    public class SimpleContainer {

        private Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

        private Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

        // Avoid cycles in the resolution
        private List<ConstructorInfo> _resolved = new List<ConstructorInfo>();

        public void RegisterType<T>(bool Singleton = false) where T : class {
            if (Singleton && _singletons.ContainsKey(typeof(T)) == false) {
                _singletons.Add(typeof(T), newInstance<T>());
            }
        }

        public void RegisterType<From, To>(bool Singleton = false) 
                where To : class 
                where From : class 
            {
            _types[typeof(From)] = typeof(To);
            if(Singleton) {
                _singletons.Add(typeof(From), newInstance<To>());
            }
        }

        public T Resolve<T>() {
            
            if(_singletons.ContainsKey(typeof(T))) {
                return (T)_singletons[typeof(T)];
            }

            ConstructorInfo[] ctorsInfo = typeof(T).GetConstructors();

            
            // Type T has no constructor OR
            // has only one constuctor that has no parameters
            if(ctorsInfo.Length == 0  || (ctorsInfo.Length == 1 
                                   && ctorsInfo[0].GetParameters().Length == 0))
            {
                return ResolveType<T>();
            }
            
            // Find a contructor which has the most parameters
            // If more than one exists, then an arbitrary one is chosen
            ConstructorInfo ctor = ctorsInfo[0];

            foreach(var c in ctorsInfo) {
                if(c.GetParameters().Length > ctor.GetParameters().Length) {
                    ctor = c;
                }
            }
            List<object> ctorParams = new List<object>();

            foreach(var param in ctor.GetParameters()) {
                Type P = param.ParameterType;
                try {
                    MethodInfo method = typeof(SimpleContainer).GetMethod("Resolve");
                    MethodInfo generic = method.MakeGenericMethod(P);
                    generic.Invoke(this, null);
                    ctorParams.Add(generic.Invoke(this, null));
                } catch(Exception) {
                    throw new Exception(
                        "SimpleContainer: failed to resolve type recursively: " 
                        + P.ToString());
                }
            }

            return (T) Activator.CreateInstance(typeof(T), ctorParams.ToArray());
        }

        private T ResolveType<T>() {
            /*
             * [Recursion base] Resolves a type with only one paramterless ctor
             */

            if(_types.ContainsKey(typeof(T))) {
                return (T) Activator.CreateInstance(_types[typeof(T)]);
            }
            T t;
            try {
                t = newInstance<T>();
            } catch(Exception e) {
                throw new Exception("SimpleContainer: no such type registered: " + typeof(T).ToString());
            } 
            return t;
        }

        private T newInstance<T>() {
            return Activator.CreateInstance<T>();
        }

        public void RegisterInstance<T>(T Instance) {
            _singletons[typeof(T)] = Instance;
        }
    }
}