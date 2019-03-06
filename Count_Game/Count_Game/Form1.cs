using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;

namespace Count_Game
{
    public partial class Count_game : Form
    {
        public Count_game()
        {
            InitializeComponent();
        }
        int count = 0;
        private int Thong_bao()
        {

            string[] listgame = File.ReadAllLines(@"input.txt");
            Process[] ListProcess = Process.GetProcesses();
            foreach (string list in listgame)
            {
                foreach (Process process in ListProcess)
                {
                    if (process.ProcessName == list)
                    {
                        count++;
                        if (count > 1)
                            return 0;
                        DialogResult tb = MessageBox.Show(new Form() { TopMost = true },"Tao tắt game của mày nha", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (tb == DialogResult.Yes)
                        {
                            process.Kill();
                        }
                        else
                        {
                            DialogResult tb1 = MessageBox.Show(new Form() { TopMost = true }, "Mày có chắc là mày không muốn tắt game không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (tb1 == DialogResult.No)
                            {
                                process.Kill();
                            }
                            else
                            {
                                DialogResult tb2 = MessageBox.Show(new Form() { TopMost = true }, "Yes để tắt game, No để mất thời gian và game vẫn tắt.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (tb2 == DialogResult.Yes)
                                {
                                    process.Kill();
                                }
                                else
                                {
                                    MessageBox.Show(new Form() { TopMost = true }, "Mày hết thuốc chữa rồi, Nên tao phải tắt game của mày đi thôi", "Thông báo");
                                    process.Kill();
                                }
                            }
                        }
                        return 1;
                    }
                }
            };
            count = 0;
            return 0;
        }
        private void ShowTime(int Day, int Hour, int Minute, int Second)
        {
            Label_day.Text = Day.ToString() + " Day";
            label_hour.Text = Hour.ToString() + " Hour";
            label_min.Text = Minute.ToString() + " Min";
            label_sec.Text = Second.ToString() + " Sec";
        }
        private void TimGame()
        {
            //Doc du lieu tu file input
            string[] listgame = File.ReadAllLines(@"input.txt");

            //Mo file output de ghi du lieu
            FileStream output = new FileStream(@"output.txt", FileMode.Open);
            StreamWriter lastplaygame = new StreamWriter(output, Encoding.UTF8);

            //Mo process de lay cac phan mem dang chay
            Process[] ListProcess = Process.GetProcesses();
            //Duyet tim xem co game khong
            foreach (string list in listgame)
            {
                foreach (Process process in ListProcess)
                {
                    if (process.ProcessName == list)
                    {
                        //Tra ve thoi gian luc co game
                        lastplaygame.WriteLine(DateTime.Now.DayOfYear.ToString());
                        lastplaygame.WriteLine(DateTime.Now.Hour.ToString());
                        lastplaygame.WriteLine(DateTime.Now.Minute.ToString());
                        lastplaygame.WriteLine(DateTime.Now.Second.ToString());
                    }
                }
            };
            //Dong file
            lastplaygame.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int dayofyear = 0, hour = 0, min = 0, sec = 0;
            DateTime now = DateTime.Now;
            TimGame();
            string[] listgame = File.ReadAllLines(@"output.txt");

            //Gan thoi gian
            dayofyear = Convert.ToInt32(now.DayOfYear.ToString()) - Convert.ToInt32(listgame[0].ToString());
            hour = Convert.ToInt32(now.Hour.ToString()) - Convert.ToInt32(listgame[1].ToString());
            min = Convert.ToInt32(now.Minute.ToString()) - Convert.ToInt32(listgame[2].ToString());
            sec = Convert.ToInt32(now.Second.ToString()) - Convert.ToInt32(listgame[3].ToString());

            //Xu ly neu sec, min, hour am
            if (sec < 0)
            {
                min++;
                sec += Convert.ToInt32(listgame[3].ToString());
            }
            if (min < 0)
            {
                hour++;
                min += Convert.ToInt32(listgame[2].ToString());
            }
            if (hour < 0)
            {
                dayofyear++;
                hour += Convert.ToInt32(listgame[1].ToString());
            }

            //Hien thi
            ShowTime(dayofyear, hour, min, sec);

            //Note
            if (dayofyear >= 1)
            {
                Label_note.Text = "Wowww, Bạn giỏi quá.\nĐã hơn 1 ngày không chơi game rồi. \nTiếp tục phát huy nha";
                PBox1.Image = Image.FromFile(@"E:\WordSpace\Visual Studio 2017\Count_Game\Count_Game\Resources\hanhphuc.jpg");
            }
            else if (hour > 10)
            {

                Label_note.Text = "Hãy nghĩ tới tương lai tươi sáng \nphía trước.\nBỏ game là quyết định \nsáng suốt đấy";
                PBox1.Image = Image.FromFile(@"E:\WordSpace\Visual Studio 2017\Count_Game\Count_Game\Resources\kimochi.jpeg");
            }
            else if (min < 10)
            {
                Label_note.Text = "Haizzz, Mày lại chơi game à.\nBiết ba mẹ ở nhà làm cực khổ lắm\nkhông?. \nLà người chứ có phải CHÓ đâu mà \nnói không nghe hả";
                PBox1.Image = Image.FromFile(@"E:\WordSpace\Visual Studio 2017\Count_Game\Count_Game\Resources\tucgian.jpg");
            }
            if (dayofyear == 0 && hour == 0 && min <= 5)
            {
                Label_note.Text = "Mỗi lần chơi game mày phải nghĩ \ntới bố mẹ cực khổ ở nhà.\nLần cuối tao khuyên mày đấy.\nMày hết thuốc chữa rồi con chó ạ";
                PBox1.Image = Image.FromFile(@"E:\WordSpace\Visual Studio 2017\Count_Game\Count_Game\Resources\khinh.png");
            }
            Thong_bao();
        }

        private void Count_game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tao đéo cho mày tắt đấy", "Thug life :3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }

    }
}
