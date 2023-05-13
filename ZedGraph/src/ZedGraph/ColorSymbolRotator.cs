namespace ZedGraph
{
    using System;
    using System.Drawing;

    public class ColorSymbolRotator
    {
        public static readonly Color[] COLORS;
        public static readonly SymbolType[] SYMBOLS;
        private static ColorSymbolRotator _staticInstance;
        protected int colorIndex;
        protected int symbolIndex;

        static ColorSymbolRotator()
        {
            Color[] colorArray = new Color[10];
            colorArray[0] = Color.Red;
            colorArray[1] = Color.Blue;
            colorArray[2] = Color.Green;
            colorArray[3] = Color.Purple;
            colorArray[4] = Color.Cyan;
            colorArray[5] = Color.Pink;
            colorArray[6] = Color.LightBlue;
            colorArray[7] = Color.PaleVioletRed;
            colorArray[8] = Color.SeaGreen;
            colorArray[9] = Color.Yellow;
            COLORS = colorArray;
            SymbolType[] typeArray = new SymbolType[] { SymbolType.Circle, SymbolType.Diamond, SymbolType.Plus };
            typeArray[4] = SymbolType.Star;
            typeArray[5] = SymbolType.Triangle;
            typeArray[6] = SymbolType.TriangleDown;
            typeArray[7] = SymbolType.XCross;
            typeArray[8] = SymbolType.HDash;
            typeArray[9] = SymbolType.VDash;
            SYMBOLS = typeArray;
        }

        public Color NextColor =>
            COLORS[this.NextColorIndex];

        public int NextColorIndex
        {
            get
            {
                int num;
                if (this.colorIndex >= COLORS.Length)
                {
                    this.colorIndex = 0;
                }
                this.colorIndex = (num = this.colorIndex) + 1;
                return num;
            }
            set => 
                this.colorIndex = value;
        }

        public SymbolType NextSymbol =>
            SYMBOLS[this.NextSymbolIndex];

        public int NextSymbolIndex
        {
            get
            {
                int num;
                if (this.symbolIndex >= SYMBOLS.Length)
                {
                    this.symbolIndex = 0;
                }
                this.symbolIndex = (num = this.symbolIndex) + 1;
                return num;
            }
            set => 
                this.symbolIndex = value;
        }

        public static ColorSymbolRotator StaticInstance
        {
            get
            {
                _staticInstance ??= new ColorSymbolRotator();
                return _staticInstance;
            }
        }

        public static Color StaticNextColor =>
            StaticInstance.NextColor;

        public static SymbolType StaticNextSymbol =>
            StaticInstance.NextSymbol;
    }
}

