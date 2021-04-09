using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace WpfApp.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {


        private string _expression;
        public string Expression { get => _expression; set => SetProperty(ref _expression, value); }
		

        private string _text;
        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public ShellWindowViewModel()
        {
            TestCmd = new(test);
        }

        public DelegateCommand TestCmd { get; private set; }
        private void test()
        {
            phytonInterop();
            //excelInterop();
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

        private void phytonInterop()
        {
            ScriptEngine scriptEngine = Python.CreateEngine();
            ScriptScope scope = scriptEngine.CreateScope();
            scope.SetVariable("L80", 1023);
            try
            {
            Text = scriptEngine.Execute(Expression,scope).ToString();
                ScriptSource scriptSource = scriptEngine.CreateScriptSourceFromString(Expression, Microsoft.Scripting.SourceCodeKind.Expression);
                Text= scriptSource.Execute(scope).ToString();
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
            
        }
    }
}
