/**
 *  Copyright (C) 2008 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System;
using System.Collections.Generic;
using System.Drawing;

namespace KnightRider.ElectionTracker.reports {
    public abstract class BaseReport<T> : IReport<T> {
        private static readonly Font printFont = new Font("Courier New", 10);


        protected readonly IList<String> header = new List<string>();
        protected readonly IList<String> body = new List<string>();
        protected readonly IList<String> footer = new List<string>();
        private bool isGenerated;
        private readonly string name;
        private readonly bool isLandscape;

        public BaseReport(string name, bool isLandscape) {
            this.name = name;
            this.isLandscape = isLandscape;
        }

        public string Name() {
            return name;
        }

        public void Generate(T entity) {
            isGenerated = performGenerate(entity);
        }

        protected abstract bool performGenerate(T entity);

        private void checkGenerated() {
            if (!isGenerated) throw new Exception("Report not generted");
        }

        public List<string> Header() {
            checkGenerated();
            return new List<String>(header);
        }

        public List<string> Body() {
            checkGenerated();
            return new List<String>(body);
        }

        public List<string> Footer() {
            checkGenerated();
            return new List<String>(footer);
        }

        public void Reset() {
            header.Clear();
            body.Clear();
            footer.Clear();
            isGenerated = false;
        }

        public bool IsLandscape() {
            return isLandscape;
        }

        public virtual Font Font() {
            return printFont;
        }

        protected string CenterText(string text) {
            return CenterText(text, ' ');
        }

        protected static string FormatTextLength(string text, int length, bool padRight) {
            int textLength = text.Length;
            string result = text;
            if (textLength > length) {
                result = text.Substring(0, length);
            } else {
                while (result.Length < length) {
                    if (padRight) {
                        result = result + " ";
                    } else {
                        result = " " + result;
                    }
                }
            }
            return result;
        }

        protected static string FormatTextLength(string text, int length) {
            return FormatTextLength(text, length, true);
        }

        protected string CenterText(string text, char space) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length) / 2); i++) {
                text = "" + space + text + space;
            }
            return text;
        }

        protected string AlignRight(string text) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length)); i++) {
                text = " " + text;
            }
            return text;
        }

        private int GetMarginSpot() {
            if (isLandscape) {
                return 105;
            } else {
                return 75;
            }
        }
    }
}