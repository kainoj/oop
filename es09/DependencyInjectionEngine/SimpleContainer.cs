using System;
using System.Collections.Generic;

namespace simplecontainer
{
    public class SimpleContainer {

        private Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

        private Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

        public void RegisterType<T>(bool Singleton = false) where T : class {
            if (Singleton && _singletons.ContainsKey(typeof(T)) == false) {
                _singletons.Add(typeof(T), newInstance<T>());
            }
        }

        public void RegisterType<From, To>( bool Singleton = false ) 
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
            if(_types.ContainsKey(typeof(T))) {
                return (T) Activator.CreateInstance( _types[typeof(T)]);
            }
            T t;
            try {
                t = newInstance<T>();
            } catch(Exception e) {
                throw new Exception("No such type registered");
            } 
            return t;
        }

        private T newInstance<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}