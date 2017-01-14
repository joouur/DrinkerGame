using System;
using System.Collections.Generic;
using UnityEngine;

namespace ColorAsset
{
    [Serializable]
    public class Colors
    {
        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField]
        private Color color;
        public Color TheColor
        {
            get { return color; }
            set { color = value; }
        }

        [SerializeField]
        private int iD;
        public int ID
        {
            get { return iD; }
            set
            { iD = value; }
        }

        public Colors()
        {
            Name = "NULL";
            TheColor = new Color(0, 0, 0, 0);
        }

        public Colors(string name, Color color)
        {
            Name = name;
            TheColor = new Color(color.r, color.g, color.b, color.a);
        }

        public override int GetHashCode()
        {
            return this.iD;
        }

        public override bool Equals(object obj)
        {
            Colors otherColor = obj as Colors;
            if(otherColor != null)
            { return this.iD.Equals(otherColor.iD); }
            else
            { throw new ArgumentException(); }
        }
    }

    [Serializable]
    public class ColorTool : ScriptableObject
    {
        public bool AddBaseColors = true;

        public HashSet<Colors> colorPickerHash = new HashSet<Colors>();
        public List<Colors> colorPicker = new List<Colors>();

        public ColorTool()
        {
            if (AddBaseColors)
            {
                Colors r = new Colors("RED", new Color((244 / 255.0f), (67 / 255.0f), (54 / 255.0f), 1.0f));
                Colors p = new Colors("PINK", new Color((233 / 255.0f), (30 / 255.0f), (99 / 255.0f), 1.0f));
                Colors pu = new Colors("PURPLE", new Color((156 / 255.0f), (39 / 255.0f), (176 / 255.0f), 1.0f));
                Colors dp = new Colors("DEEP_PURPLE", new Color((103 / 255.0f), (58 / 255.0f), (183 / 255.0f), 1.0f));
                Colors i = new Colors("INDIGO", new Color((63 / 255.0f), (81 / 255.0f), (181 / 255.0f), 1.0f));
                Colors b = new Colors("BLUE", new Color((33 / 255.0f), (150 / 255.0f), (243 / 255.0f), 1.0f));
                Colors lb = new Colors("LIGHT_BLUE", new Color((3 / 255.0f), (169 / 255.0f), (244 / 255.0f), 1.0f));
                Colors c = new Colors("CYAN", new Color(0, (188 / 255.0f), (212 / 255.0f), 1.0f));
                Colors t = new Colors("TEAL", new Color(0, (150 / 255.0f), (136 / 255.0f), 1.0f));
                Colors g = new Colors("GREEN", new Color((76 / 255.0f), (175 / 255.0f), (80 / 255.0f), 1.0f));
                Colors lg = new Colors("LIGHT_GREEN", new Color((139 / 255.0f), (195 / 255.0f), (74 / 255.0f), 1.0f));
                Colors li = new Colors("LIME", new Color((205 / 255.0f), (220 / 255.0f), (57 / 255.0f), 1.0f));
                Colors y = new Colors("YELLOW", new Color((255 / 255.0f), (235 / 255.0f), (59 / 255.0f), 1.0f));
                Colors a = new Colors("AMBER", new Color((255 / 255.0f), (193 / 255.0f), (7 / 255.0f), 1.0f));
                Colors o = new Colors("ORANGE", new Color((255 / 255.0f), (152 / 255.0f), (0 / 255.0f), 1.0f));
                Colors dor = new Colors("DEEP_ORANGE", new Color((255 / 255.0f), (87 / 255.0f), (34 / 255.0f), 1.0f));
                Colors br = new Colors("BROWN", new Color((121 / 255.0f), (85 / 255.0f), (72 / 255.0f), 1.0f));
                Colors gr = new Colors("GREY", new Color((158 / 255.0f), (158 / 255.0f), (158 / 255.0f), 1.0f));
                Colors bgr = new Colors("BLUE_GREY", new Color((96 / 255.0f), (125 / 255.0f), (139 / 255.0f), 1.0f));

                colorPicker.Add(r);
                colorPicker.Add(p);
                colorPicker.Add(pu);
                colorPicker.Add(dp);
                colorPicker.Add(i);
                colorPicker.Add(b);
                colorPicker.Add(lb);
                colorPicker.Add(c);
                colorPicker.Add(t);
                colorPicker.Add(g);
                colorPicker.Add(lg);
                colorPicker.Add(li);
                colorPicker.Add(y);
                colorPicker.Add(a);
                colorPicker.Add(o);
                colorPicker.Add(dor);
                colorPicker.Add(br);
                colorPicker.Add(gr);
                colorPicker.Add(bgr);
            }

        }
    }

}