﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace WiiTUIO.Output.Handlers
{
    public class MouseHandler : IButtonHandler, IStickHandler
    {
        private InputSimulator inputSimulator;

        public MouseHandler()
        {
            this.inputSimulator = new InputSimulator();
        }

        public bool setButtonDown(string key)
        {
            if (Enum.IsDefined(typeof(MouseCode), key.ToUpper()))
            {
                MouseCode mouseCode = (MouseCode)Enum.Parse(typeof(MouseCode), key, true);
                switch (mouseCode)
                {
                    case MouseCode.MOUSELEFT:
                        this.inputSimulator.Mouse.LeftButtonDown();
                        break;
                    case MouseCode.MOUSERIGHT:
                        this.inputSimulator.Mouse.RightButtonDown();
                        break;
                    default:
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool setButtonUp(string key)
        {
            if (Enum.IsDefined(typeof(MouseCode), key.ToUpper()))
            {
                MouseCode mouseCode = (MouseCode)Enum.Parse(typeof(MouseCode), key, true);
                switch (mouseCode)
                {
                    case MouseCode.MOUSELEFT:
                        this.inputSimulator.Mouse.LeftButtonUp();
                        break;
                    case MouseCode.MOUSERIGHT:
                        this.inputSimulator.Mouse.RightButtonUp();
                        break;
                    default:
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool setValue(string key, double value)
        {
            key = key.ToLower();
            switch (key)
            {
                case "mousey+":
                    this.inputSimulator.Mouse.MoveMouseBy(0, (int)(-30 * value + 0.5));
                    break;
                case "mousey-":
                    this.inputSimulator.Mouse.MoveMouseBy(0, (int)(30 * value + 0.5));
                    break;
                case "mousex+":
                    this.inputSimulator.Mouse.MoveMouseBy((int)(30 * value + 0.5), 0);
                    break;
                case "mousex-":
                    this.inputSimulator.Mouse.MoveMouseBy((int)(-30 * value + 0.5), 0);
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool connect()
        {
            return true;
        }

        public bool disconnect()
        {
            return true;
        }

        public bool startUpdate()
        {
            return true;
        }

        public bool endUpdate()
        {
            return true;
        }
    }

    public enum MouseCode
    {
        MOUSELEFT,
        MOUSERIGHT
    }
}
