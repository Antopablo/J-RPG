using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class PopUp
    {
        public List<StringBuilder> Content { get; set; }

        public bool Displayed { get; set; }

        private List<string> _text;
        public List<string> Text
        {
            get { return _text; }
            set
            {
                _text = value;
                StringBuilder horizontalBorder = new StringBuilder();
                for (int i = 0; i < _text.Max(line => line.Length + 4); i++)
                {
                    horizontalBorder.Append("#");
                }
                StringBuilder verticalSeparator = new StringBuilder();
                verticalSeparator.Append("#");
                for (int i = 0; i < horizontalBorder.Length - 2; i++)
                {
                    verticalSeparator.Append(" ");
                }
                verticalSeparator.Append("#");
                Content.Add(horizontalBorder);
                Content.Add(verticalSeparator);
                    
                Content.Add(new StringBuilder("# " + InsertLine(_text[0], horizontalBorder.Length) + " #"));
                Content.Add(verticalSeparator);
                for (int i = 1; i < _text.Count; i++)
                {
                    Content.Add(new StringBuilder("# " + InsertLine(_text[i], horizontalBorder.Length) + " #"));
                }
                Content.Add(verticalSeparator);
                Content.Add(horizontalBorder);
                Content = new List<StringBuilder>();
            }
        }

        public PopUp()
        {
            Displayed = false;
        }

        private StringBuilder InsertLine(string line, int popWidth)
        {
            StringBuilder insert = new StringBuilder();
            insert.Append(line);
            for (int i = 0; i < popWidth - 4 - line.Length; i++)
            {
                insert.Append(" ");
            }
            return insert;
        }

        public void Clear ()
        {
            _text.Clear();
            Content.Clear();
            Displayed = false;
        }
    }
}
