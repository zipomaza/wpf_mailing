using KozyrevDenis_WpfApplication.Commands;
using KozyrevDenis_WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace KozyrevDenis_WpfApplication.ViewModels
{
    class ViewModelMailSender:ViewModelBase
    {
        public ICommand EnterCommand { get; set; }
        public string UserName {

            get
            {
                return _username;
            }
            set
            {
                UpdateValue(value, ref _username);
            }
        }
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                UpdateValue(value, ref _from);
            }
        }
        public string To
        {
            get { return _to; }
            set
            {
                UpdateValue(value, ref _to);
            }
        }
        
        public ViewModelMailSender()
        {
            ConfigureCommands();
        }

        private void ConfigureCommands()
        {
            EnterCommand = new Command<PasswordBox>(EnterCommandExecute);
        }

        private void EnterCommandExecute(PasswordBox password)
        {
            _password = password.Password;
            if (UserName!="" && To!="" && From!="" && _password!="")
                EmailSender.Send(UserName, _password, "smtp.mail.ru", From, To);
        }
        
        private string _username,_password,_to,_from;

    }
}
