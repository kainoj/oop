

namespace Ex7 {

    public interface IReport {
        string getData();
        void formatDocumet();
    }
    public interface IDocumentFormatter {
        string formatDocumet(IReport report);
    }

    public interface IReportPrinter {
        void printReport(string data);
    }


    public class ReportComposer{

        public ReportComposer(IReport report, IDocumentFormatter docFormattter, IReportPrinter reportPrinter) {
            report.formatDocumet();
            string data = report.getData();
            reportPrinter.printReport(data);
        }
    }    

}