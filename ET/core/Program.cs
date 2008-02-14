/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
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
using System.Windows.Forms;
using Common.Logging;
using edu.uwec.cs.cs355.group4.et.ui;
using Spring.Context;
using Spring.Context.Support;

namespace edu.uwec.cs.cs355.group4.et.core {
    internal static class Program {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (Program));

        [STAThread]
        public static void Main(string[] args) {
            try {
                Application.EnableVisualStyles();
                IApplicationContext ctx = ContextRegistry.GetContext("spring.root");
                UIController controller = (UIController) ctx.GetObject("UIController");
                Application.Run(controller.getMDIForm());
            } catch (Exception ex) {
                LOG.Error(ex.Message, ex);
            }
        }
    }
}