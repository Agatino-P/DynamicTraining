using Prism.Commands;
using Prism.Mvvm;
using System;

namespace WpfApp.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {

        private string _text;
        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public ShellWindowViewModel()
        {
            TestCmd = new(test);
        }

        public DelegateCommand TestCmd { get; private set; }
        private void test()
        {
            excelInterop();
        }
        private void excelInterop()
        {

            Type excelType = Type.GetTypeFromProgID("Excel.Application", true);
            dynamic excel = Activator.CreateInstance(excelType);
            excel.Visible = true;
            excel.WorkBooks.Add();
            dynamic activeSheet = excel.ActiveSheet;
            activeSheet.Cells[1, "A"] = "Pippo";
        }
    }
}
