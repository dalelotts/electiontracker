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
using System.Windows.Forms;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.reports {
    public abstract class BaseReport<T> : IReport {
        private static readonly Font printFont = new Font("Courier New", 10);


        protected readonly IList<String> header = new List<string>();
        protected readonly IList<String> body = new List<string>();
        protected readonly IList<String> footer = new List<string>();
        private bool isGenerated;
        private readonly string name;
        private readonly bool isLandscape;
        private readonly IList<TreeViewFilter> filters;
        private int marginPoint;
        private T selectedEntity = default(T);

        public BaseReport(string name, bool isLandscape, IList<TreeViewFilter> filters) {
            this.name = name;
            this.isLandscape = isLandscape;
            this.filters = filters;
            marginPoint = isLandscape ? 105 : 82;
        }

        public string Name() {
            return name;
        }

        public void Generate() {
            isGenerated = performGenerate(selectedEntity);
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

        public List<TreeViewFilter> Filters() {
            return new List<TreeViewFilter>(filters);
        }

        public void NodeSelected(TreeNode node) {
            selectedEntity = (T) node.Tag;
        }

        protected string CenterText(string text) {
            return CenterText(text, ' ');
        }

        protected static string PadString(string text, int length, bool padRight) {
            return PadString(text, length, ' ', padRight);
        }

        protected static string PadString(string text, int length, char padChar, bool padRight) {
            int textLength = text.Length;
            string result = text;
            if (textLength > length) {
                result = text.Substring(0, length);
            } else {
                while (result.Length < length) {
                    if (padRight) {
                        result = result + padChar;
                    } else {
                        result = padChar + result;
                    }
                }
            }
            return result;
        }

        protected static string PadString(string text, int length) {
            return PadString(text, length, true);
        }

        protected string CenterText(string text, char space) {
            // ToDo: Use actual margins and character sizes to center.
            int length = text.Length;
            for (int i = 0; i <= ((marginPoint - length) / 2); i++) {
                text = space + text + space;
            }
            return text;
        }

        protected string AlignRight(string text) {
            int length = text.Length;
            for (int i = 0; i <= ((marginPoint - length)); i++) {
                text = " " + text;
            }
            return text;
        }
    }
}