using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inlamning_3_ra_kod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Inlamning_3_ra_kod.Tests
{
    [TestClass()]
    public class CStackTests
    {
        [TestMethod()]
        public void CStackTest()
        {
            CStack cs = new CStack();

            Assert.AreEqual(cs.X, 0);
            Assert.AreEqual(cs.Y, 0);
            Assert.AreEqual(cs.Z, 0);
            Assert.AreEqual(cs.T, 0);
            string[,] _address = new string[8, 2] {
                { "A", "0" },
                { "B", "0" },
                { "C", "0" },
                { "D", "0" },
                { "E", "0" },
                { "F", "0" },
                { "G", "0" },
                { "H", "0" }
            };

            for (int i = 0; i < _address.GetLength(0); i++)
            {
                Assert.AreEqual(cs.address[i,0], _address[i,0]);
                Assert.AreEqual(cs.address[i,1], _address[i,1]);
            }
            Assert.AreEqual(cs.entry, "");
            Assert.AreEqual(cs.entryVar, "");
        }

        [TestMethod()]
        public void CStackTest1()
        {
            SaveVarInFileTest();
        }

        [TestMethod()]
        public void ExitTest()
        {
            SaveVarInFileTest();
        }

        [TestMethod()]
        public void StackStringTest()
        {
            CStack cs = new CStack();
            string stack = cs.StackString();
            string stackTest = "0\n0\n0\n0\n";
            Assert.AreEqual(stack, stackTest);
        }

        [TestMethod()]
        public void VarStringTest()
        {
            CStack cs = new CStack();
            string stack = cs.VarString();
            string stackVar = "0\n0\n0\n0\n0\n0\n0\n0";
            Assert.AreEqual(stack, stackVar);
        }

        [TestMethod()]
        public void SetXTest()
        {
            CStack cs = new CStack();
            cs.SetX(10);
            Assert.AreEqual(cs.X, 10);

        }

        [TestMethod()]
        public void EntryAddNumTest()
        {
            CStack cs = new CStack();
            cs.EntryAddNum("5");
            Assert.AreEqual(cs.entry, "5");
        }

        [TestMethod()]
        public void EntryAddCommaTest()
        {
            CStack cs = new CStack();
            cs.EntryAddComma();
            Assert.AreNotEqual(cs.entry.IndexOf(","), -1);
        }

        [TestMethod()]
        public void EntryChangeSignTest()
        {
            CStack cs = new CStack();
            cs.entry = "5";
            cs.EntryChangeSign();
            Assert.AreEqual(cs.entry, "-5");
            cs.EntryChangeSign();
            Assert.AreEqual(cs.entry, "+5");

            cs.entry = "5";
            cs.Enter();
            cs.EntryChangeSign();
            Assert.AreEqual(cs.entry, "-");
        }

        [TestMethod()]
        public void EnterTest()
        {
            CStack cs = new CStack();
            cs.entry = "5";
            cs.Enter();
            Assert.AreEqual(cs.X, 5);
            Assert.AreEqual(cs.entry, "");
        }

        [TestMethod()]
        public void DropTest()
        {
            CStack cs = new CStack();
            cs.entry = "1";
            cs.Enter();
            cs.entry = "2";
            cs.Enter();
            cs.entry = "3";
            cs.Enter();
            cs.entry = "4";
            cs.Enter();
            cs.Drop();
            Assert.AreEqual(cs.X, 3);
            Assert.AreEqual(cs.Y, 2);
            Assert.AreEqual(cs.Z, 1);
            Assert.AreEqual(cs.T, 0);

        }

        [TestMethod()]
        public void DropSetXTest()
        {
            CStack cs = new CStack();
            cs.entry = "1";
            cs.Enter();
            cs.entry = "2";
            cs.Enter();
            cs.entry = "3";
            cs.Enter();

            Assert.AreEqual(cs.T, 0);
            Assert.AreEqual(cs.Z, 1);
            Assert.AreEqual(cs.Y, 2);
            Assert.AreEqual(cs.X, 3);

            cs.DropSetX(4);
            Assert.AreEqual(cs.T, 0);
            Assert.AreEqual(cs.Z, 0);
            Assert.AreEqual(cs.Y, 1);
            Assert.AreEqual(cs.X, 4);
        }

        [TestMethod()]
        public void BinOpTest()
        {
            CStack cs = new CStack();
            cs.entry = "5";
            cs.Enter();
            cs.entry = "5";
            cs.Enter();
            cs.BinOp("+");
            Assert.AreEqual(cs.X, 10);

            CStack cs2 = new CStack();
            cs2.entry = "15";
            cs2.Enter();
            cs2.entry = "5";
            cs2.Enter();
            cs2.BinOp("-");
            Assert.AreEqual(cs2.X,5);

            CStack cs3 = new CStack();
            cs3.entry = "2";
            cs3.Enter();
            cs3.entry = "5";
            cs3.Enter();
            cs3.BinOp("*");
            Assert.AreEqual(cs3.X, 5);

            CStack cs4 = new CStack();
            cs4.entry = "10";
            cs4.Enter();
            cs4.entry = "2";
            cs4.Enter();
            cs4.BinOp("÷");
            Assert.AreEqual(cs4.X, 5);

            CStack cs5 = new CStack();
            cs5.entry = "5";
            cs5.Enter();
            cs5.entry = "2";
            cs5.Enter();
            cs5.BinOp("yˣ");
            Assert.AreEqual(cs5.X, 25);

            CStack cs6 = new CStack();
            cs6.entry = "9";
            cs6.Enter();
            cs6.entry = "2";
            cs6.Enter();
            cs6.BinOp("ˣ√y");
            Assert.AreEqual(cs6.X, 3);


        }

        [TestMethod()]
        public void UnopTest()
        {
            // Powers & Logarithms:
            CStack cs = new CStack();
            cs.entry = "5";
            cs.Enter();
            cs.Unop("x²");
            Assert.AreEqual(cs.X, 25);

            CStack cs2 = new CStack();
            cs2.entry = "25";
            cs2.Enter();
            cs2.Unop("√x");
            Assert.AreEqual(cs2.X, 5);

            CStack cs3 = new CStack();
            cs3.entry = "22";
            cs3.Enter();
            cs3.Unop("log x");
            Assert.AreEqual(cs3.X, 1,34242268082221);

            CStack cs4 = new CStack();
            cs4.entry = "10";
            cs4.Enter();
            cs4.Unop("ln x");
            Assert.AreEqual(cs4.X, 2, 30258509299405);

            CStack cs5 = new CStack();
            cs5.entry = "";
            cs5.Enter();
            cs5.Unop("10ˣ");
            Assert.AreEqual(cs5.X, 1);

            CStack cs6 = new CStack();
            cs6.entry = "0";
            cs6.Enter();
            cs6.Unop("eˣ");
            Assert.AreEqual(cs6.X, 1);

            // Trigonometry:
            CStack cs7 = new CStack();
            cs7.entry = "10";
            cs7.Enter();
            cs7.Unop("sin");
            Assert.AreEqual(cs7.X, -0, 54402111088937);

            CStack cs8 = new CStack();
            cs8.entry = "15";
            cs8.Enter();
            cs8.Unop("cos");
            Assert.AreEqual(cs8.X, -0, 759687912858821);

            CStack cs9 = new CStack();
            cs9.entry = "20";
            cs9.Enter();
            cs9.Unop("tan");
            Assert.AreEqual(cs9.X, 2, 23716094422474);

            CStack cs10 = new CStack();
            cs10.entry = "0,10";
            cs10.Enter();
            cs10.Unop("sin⁻¹");
            Assert.AreEqual(cs10.X, 0, 10016742116156);

            CStack cs11 = new CStack();
            cs11.entry = "0,10";
            cs11.Enter();
            cs11.Unop("cos⁻¹");
            Assert.AreEqual(cs11.X, 1, 47062890563334);

            CStack cs12 = new CStack();
            cs12.entry = "0,10";
            cs12.Enter();
            cs12.Unop("tan⁻¹");
            Assert.AreEqual(cs12.X, 0, 099668652491162);


        }

        [TestMethod()]
        public void NilopTest()
        {
            CStack cs = new CStack();
            cs.Nilop("π");
            Assert.AreEqual(cs.X, 3,14);

            CStack cs2 = new CStack();
            cs2.Nilop("e");
            Assert.AreEqual(cs.X, 2,71828182845904);
        }

        [TestMethod()]
        public void RollTest()
        {
            CStack cs = new CStack();
            cs.X = 1;
            cs.Y = 2;
            cs.Z = 3;
            cs.T = 4;
            cs.Roll();
            Assert.AreEqual(cs.X, 4);
            Assert.AreEqual(cs.Y, 1);
            Assert.AreEqual(cs.Z, 2);
            Assert.AreEqual(cs.T, 3);
        }

        [TestMethod()]
        public void RollSetXTest()
        {
            CStack cs = new CStack();
            cs.entry = "1";
            cs.Enter();
            cs.entry = "2";
            cs.Enter();
            cs.entry = "3";
            cs.Enter();

            Assert.AreEqual(cs.T, 0);
            Assert.AreEqual(cs.Z, 1);
            Assert.AreEqual(cs.Y, 2);
            Assert.AreEqual(cs.X, 3);

            cs.RollSetX(4);
            Assert.AreEqual(cs.T, 1);
            Assert.AreEqual(cs.Z, 2);
            Assert.AreEqual(cs.Y, 3);
            Assert.AreEqual(cs.X, 4);
        }

        [TestMethod()]
        public void SetAddressTest()
        {
            CStack cs = new CStack();
            cs.SetAddress("A");
            Assert.AreEqual(cs.entryVar, "A");
        }

        [TestMethod()]
        public void SetVarTest()
        {
            CStack cs = new CStack();
            cs.entry = "20";
            cs.Enter();
            cs.SetAddress("A");
            cs.SetVar();
            Assert.AreEqual(cs.address[0, 1], "20");
        }

        [TestMethod()]
        public void GetVarTest()
        {
            CStack cs = new CStack();
            cs.entry = "1";
            cs.Enter();
            cs.SetAddress("A");
            cs.SetVar();

            cs.entry = "2";
            cs.Enter();
            cs.SetAddress("B");
            cs.SetVar();

            cs.entry = "3";
            cs.Enter();
            cs.SetAddress("C");
            cs.SetVar();

            cs.entry = "4";
            cs.Enter();
            cs.SetAddress("D");
            cs.SetVar();

            cs.entry = "5";
            cs.Enter();
            cs.SetAddress("E");
            cs.SetVar();

            cs.entry = "6";
            cs.Enter();
            cs.SetAddress("F");
            cs.SetVar();

            cs.entry = "7";
            cs.Enter();
            cs.SetAddress("G");
            cs.SetVar();

            cs.entry = "8";
            cs.Enter();
            cs.SetAddress("H");
            cs.SetVar();

            cs.GetVar();
            Assert.AreEqual(cs.address[0,1], "1");
            Assert.AreEqual(cs.address[1,1], "2");
            Assert.AreEqual(cs.address[2,1], "3");
            Assert.AreEqual(cs.address[3,1], "4");
            Assert.AreEqual(cs.address[4,1], "5");
            Assert.AreEqual(cs.address[5,1], "6");
            Assert.AreEqual(cs.address[6,1], "7");
            Assert.AreEqual(cs.address[7,1], "8");
           

        }

        [TestMethod()]
        public void SaveVarInFileTest()
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @".\variabelFile.txt";
            CStack cs = new CStack(@".\variabelFile.txt");
            Assert.AreEqual(true, cs.fileExist);
            cs.address = new string[8, 2] {
                { "A", "1" },
                { "B", "2" },
                { "C", "3" },
                { "D", "4" },
                { "E", "5" },
                { "F", "6" },
                { "G", "7" },
                { "H", "8" }
            };
            cs.X = 8;
            cs.Y = 7;
            cs.Z = 6;
            cs.T = 5;
            cs.SaveVarInFile();

            CStack cs2 = new CStack(@".\variabelFile.txt");
            Assert.AreEqual(true, cs.fileExist);
            for (int i = 0; i < cs2.address.GetLength(0); i++)
            {
                Assert.AreEqual(cs2.address[i, 0], cs.address[i, 0]);
                Assert.AreEqual(cs2.address[i, 1], cs.address[i, 1]);
            }
            Assert.AreEqual(cs2.X, cs.X);
            Assert.AreEqual(cs2.Y, cs.Y);
            Assert.AreEqual(cs2.Z, cs.Z);
            Assert.AreEqual(cs2.T, cs.T);
        }
    }
}