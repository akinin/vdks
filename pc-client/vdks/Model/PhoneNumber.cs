﻿using System;

namespace vdks.Model
{
    public class PhoneNumber
    {
        public bool IsSaved { get; set; }
        public byte[] NumberArray;
        public string NumberString
        {
            get
            {
                var ret = "+7(";
                ret += NumberArray[0].ToString();
                ret += NumberArray[1].ToString();
                ret += NumberArray[2].ToString();
                ret += ")";
                for (var i = 3; i < 10; i++)
                {
                    ret += NumberArray[i];
                    if (i == 5 || i == 7) ret += "-";
                }
                return ret;
            }
            set 
            {
                try
                {
                    var str = value;
                    for (var i = 0; i < str.Length - 2; i++)
                    {
                        NumberArray[i] = (byte)Int32.Parse(str.Substring(i + 2, 1));
                    }
                    IsSaved = false;
                }
                catch (Exception exep)
                {
                    System.Windows.MessageBox.Show(exep.Message);
                }
                
            }

        }

        public PhoneNumber()
        {
            NumberArray = new byte[10];
        }
        public PhoneNumber(byte[] number)
        {
            NumberArray = number;
            IsSaved = true;
        }

    }
    }
