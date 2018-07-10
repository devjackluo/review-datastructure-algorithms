using PriorityQueueLinkedList;
using QueueArray;
using QueueLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueTestWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        //Test my linked list queue
        //QueueL<int> _queue = new QueueL<int>();

        //Test my Array queue
        //QueueA<int> _queue = new QueueA<int>();

        //Test my priority queue w linked list
        PriorityQueueL<int> _queue = new PriorityQueueL<int>();

        Random _rng = new Random();

        public MainWindow() {
            InitializeComponent();
        }

        private void button_Create_Click(object sender, RoutedEventArgs e) {

            //add a new item into queue
            _queue.Enqueue(_rng.Next(0, 200));
            UpdateGrid();

        }

        private void button_Process_Click(object sender, RoutedEventArgs e) {

            //if queue has more than 0
            if (_queue.Count > 0) {
                //dequeue from queue and all to listbox
                listBox.Items.Add(_queue.Dequeue().ToString());
                UpdateGrid();
            }

        }


        private void UpdateGrid() {

            //remove all label text
            lblQ1.Content = string.Empty;
            lblQ2.Content = string.Empty;
            lblQ3.Content = string.Empty;
            lblQ4.Content = string.Empty;
            lblQ5.Content = string.Empty;
            lblQ6.Content = string.Empty;

            //starting at 0
            int index = 0;
            //for all message(all node's values in list) in queue
            foreach (int message in _queue) {
                switch (index) {
                    case 0:
                        lblQ1.Content = message.ToString();
                        break;
                    case 1:
                        lblQ2.Content = message.ToString();
                        break;
                    case 2:
                        lblQ3.Content = message.ToString();
                        break;
                    case 3:
                        lblQ4.Content = message.ToString();
                        break;
                    case 4:
                        lblQ5.Content = message.ToString();
                        break;
                    case 5:
                        lblQ6.Content = message.ToString();
                        break;
                    default:
                        break;
                }

                //increment index
                index++;

                //if index greater than 5 (6th item) break out of loop
                if (index > 5) {
                    break;
                }
            }
        }


    }
}
