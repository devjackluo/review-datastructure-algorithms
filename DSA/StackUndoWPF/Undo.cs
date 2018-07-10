using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace StackUndoWPF {
    class Undo {

        Button _button;
        Brush _brush;

        public Undo(Button button) {
            _button = button;
            _brush = button.Background.CloneCurrentValue();
        }

        public void Execute() {
            _button.Background = _brush;
        }

        public override string ToString() {
            return string.Format("{0}: {1}", _button.Content, _brush.ToString());
        }

    }
}
