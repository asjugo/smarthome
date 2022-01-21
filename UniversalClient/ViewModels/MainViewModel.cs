using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversalClient.ViewModelBase;

namespace UniversalClient.ViewModels
{
    class MainViewModel : ViewModel
    {
        private ICommand _sendMessageCommand;
        private string _status;



        private string _msgToSend;
        public string MessageToSend
        {
            get { return _msgToSend; }
            set
            {
                _msgToSend = value;
                OnPropertyChanged("MessageToSend");
            }
        }

        private static string _ipAddress;
        public string IPAddressServer
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
                OnPropertyChanged("IPAddressServer");
            }
        }

        private int _serverPort;

        public int ServerPort
        {
            get { return _serverPort; }
            set
            {
                _serverPort = value;
                OnPropertyChanged("ServerPort");
            }
        }


        public ICommand SendMessageCommand
        {
            get
            {
                if (_sendMessageCommand == null)
                {
                    _sendMessageCommand = new RelayCommand(c => ExecuteSendMessageCommand());
                }
                return _sendMessageCommand;
            }
        }

        public string Status { get => _status; set => _status = value; }

        public MainViewModel()
        {
            _msgToSend = "23.5; 78.0; 1011.6; 192.168.12.43;";
            _serverPort = 2020;
            _ipAddress = "127.0.0.1";
        }

        private void ExecuteSendMessageCommand()
        {
            try
            {
                Socket _clientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                _status = "Sending Message...";
                _clientSocket.Connect(IPAddress.Parse(_ipAddress), ServerPort);

                //while (!_clientSocket.Connected)
                //    await Task.Delay(500);

                //evtl. Encoding.ASCII.GetBytes("OK");
                _clientSocket.Send(Encoding.ASCII.GetBytes(MessageToSend));

                //_clientSocket.Disconnect(false);
                //while (_clientSocket.Connected)
                //    await Task.Delay(500);

                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();

                Status = "Command sent ready.";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                throw;
            }


            //return "Command sent ready.";
        }
    }
}
