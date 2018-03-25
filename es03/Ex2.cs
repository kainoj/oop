using System;

namespace Ex2 {

    class ReportPrinter {
        private Report report;

        public ReportPrinter() {
            report = new Report("A report");
        }

        public void PrintReport() {

            // Format the report
            report.formatDocument();

            // And print it (literally)
            Console.WriteLine(report.getData());
        }
    }

    class Report {
        private string data;

        DocumetFormatter documetFormatter;

        public Report(string data) {
            this.data = data;
            documetFormatter = new DocumetFormatter();
        }

        public string getData() {
            return "Sample data";
        }

        public void formatDocument() {
            this.data = documetFormatter.formatDocument(this);
        }
    }

    class DocumetFormatter {
        public string formatDocument(Report report) {
            return "Formatted report";
        }
    }
}