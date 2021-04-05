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
            dynamic dc = DateTime.Now;
            Text = dc.ToString("ddd dd MMM yyyy HH:mm:ss.FFF");
            DateTime dts = dc;
            Text = dts.  .ToString("ddd dd MMM yyyy HH:mm:ss.FFF");
        }
    }
}
