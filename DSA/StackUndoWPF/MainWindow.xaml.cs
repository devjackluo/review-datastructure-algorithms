using StackLinkedList;
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

namespace StackUndoWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        StackL<Undo> undoOps = new StackL<Undo>();
        Random _rng = new Random();

        public MainWindow() {
            InitializeComponent();
        }

        private Brush GetRandomBrush() {
            byte[] rgb = new byte[3];
            _rng.NextBytes(rgb);

            return new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
        }

        private void btnOne_Click(object sender, RoutedEventArgs e) {
            undoOps.Push(new Undo(btnOne));
            btnOne.Background = GetRandomBrush();
            UpdateList();
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e) {
            undoOps.Push(new Undo(btnTwo));
            btnTwo.Background = GetRandomBrush();
            UpdateList();
        }

        private void btnThree_Click(object sender, RoutedEventArgs e) {
            undoOps.Push(new Undo(btnThree));
            btnThree.Background = GetRandomBrush();
            UpdateList();
        }

        private void btnFour_Click(object sender, RoutedEventArgs e) {
            undoOps.Push(new Undo(btnFour));
            btnFour.Background = GetRandomBrush();
            UpdateList();
        }

        private void btnFive_Click(object sender, RoutedEventArgs e) {
            undoOps.Push(new Undo(btnFive));
            btnFive.Background = GetRandomBrush();
            UpdateList();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e) {
            if (undoOps.Count > 0) {
                undoOps.Pop().Execute();
                UpdateList();
            }
        }

        private void UpdateList() {
            listBox.Items.Clear();

            foreach (Undo action in undoOps) {
                listBox.Items.Add(action.ToString());
            }
        }

    }
}
