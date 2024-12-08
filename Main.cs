using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace W2_DevMode
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public static class options
        {
            public static string filename = "frontend.exe";
            public static bool patched = false;    
            public static Dictionary<long, byte> plus = new Dictionary<long, byte>
            {
                //Options
                {0x58307, 0x64}, //Crate drops (%)
                {0x5832E, 0x64}, //Crate intelligence (%)
                {0x58355, 0x7D}, //First aid crates (HP)
                {0x57F3E, 0x78}, //Round Time (minutes)
                {0x57F64, 0x78}, //Turn Time (seconds)
                {0x57F66, 0x1}, //Turn Time (seconds) - Minimum
                {0x57F8A, 0x3C}, //Worm retreat (seconds)
                {0x57FB0, 0x3C}, //Rope retreat (seconds)
                {0x58275, 0x78}, //Delay between turns (seconds)
                {0x57FD6, 0x18}, //Landmines
                {0x57FFC, 0xA}, //Mine explosion delay (seconds)
                {0x5819F, 0x64}, //Repeat Swings
                {0x581A1, 0xFF}, //Repeat Swings - Minimum
                {0x581C6, 0x7D}, //Fall Damage
                {0x5829C, 0xF}, //Worms starting energy (Byte 1)
                {0x5829D, 0x27}, //Worms starting energy (Byte 2)
                {0x582A1, 0x1}, //Worms starting energy - Minimum
                {0x5820D, 0x7F}, //Land Sink Rate
                {0x5820F, 0xFF}, //Land Sink Rate - Minimum
                {0x580EC, 0x12}, //Auto Replay Kills
                {0x58113, 0x10}, //Auto Replay Damage (Byte 1)
                {0x58114, 0x27}, //Auto Replay Damage (Byte 2)
                {0x58084, 0x7D}, //Wind Strength

                //Weapons
                {0x1170B8, 0x64}, //Stock
                {0x1170C4, 0x64}, //Weapon delay
                {0x1170D0, 0x3C}, //Retreat time
                {0x1170DC, 0x64}, //Total ammo in a crate
                {0x1170E8, 0xFF}, //Bullet count
                {0x1170F4, 0x64}, //Appears in crates (%)
                {0x117100, 0xFF}, //Weapon damage
                {0x11710C, 0xFF}, //Blast power
                {0x117118, 0xFF}, //Explosion bias
                {0x117124, 0x30}, //Homing delay (milliseconds) (Byte 1)
                {0x117125, 0x75}, //Homing delay (milliseconds) (Byte 2)
                {0x117130, 0x30}, //Homing time (milliseconds) (Byte 1)
                {0x117131, 0x75}, //Homing time (milliseconds) (Byte 2)
                {0x11713C, 0xFF}, //Wind response
                {0x117148, 0xFF}, //No. clusters
                {0x117154, 0xFF}, //Cluster power (Byte 1)
                {0x117155, 0x0}, //Cluster power (Byte 2)
                {0x117160, 0xFF}, //Cluster angle
                {0x11716C, 0xFF}, //Cluster damage
                {0x117178, 0xA}, //Override fuse
                {0x117184, 0xFF}, //Amount of fire
                {0x117190, 0xFF}, //Fire spread speed
                {0x11719C, 0xFF}, //Fire period
                {0x1171A8, 0xFF}, //Impact force
                {0x1171B4, 0xFF}, //Impact angle
                {0x1171C0, 0xFF}, //Impact damage
                {0x1171CC, 0xFF}, //Jump height
                {0x1171D8, 0xFF}, //Ball damage
                {0x1171E4, 0xFF}, //Power of ball impact
                {0x1171F0, 0xFF}, //Angle of ball impact
                {0x1171FC, 0x30}, //Time of ball (Byte 1)
                {0x1171FD, 0x75}, //Time of ball (Byte 2)
                {0x117208, 0x30}, //Dig time (Byte 1)
                {0x117209, 0x75}, //Dig time (Byte 2)
                {0x117214, 0xFF}, //Bomblets
                {0x117220, 0xFF}, //Bomb damage
                {0x11722C, 0xFF}, //Bullet spread
            };
            public static Dictionary<long, byte> dev = new Dictionary<long, byte>
            {
                //Options
                {0x58307, 0x64}, //Crate drops (%)
                {0x5832E, 0x64}, //Crate intelligence (%)
                {0x58355, 0x7F}, //First aid crates (HP)
                {0x57F3E, 0x7F}, //Round Time (minutes)
                {0x57F64, 0x7F}, //Turn Time (seconds)
                {0x57F66, 0x1}, //Turn Time (seconds) - Minimum
                {0x57F8A, 0x7F}, //Worm retreat (seconds)
                {0x57FB0, 0x7F}, //Rope retreat (seconds)
                {0x58275, 0x7F}, //Delay between turns (seconds)
                {0x57FD6, 0x18}, //Landmines
                {0x57FFC, 0x7F}, //Mine explosion delay (seconds)
                {0x5819F, 0x7F}, //Repeat Swings
                {0x581A1, 0xFF}, //Repeat Swings - Minimum
                {0x581C6, 0x7F}, //Fall Damage
                {0x5829C, 0xF}, //Worms starting energy (Byte 1)
                {0x5829D, 0x27}, //Worms starting energy (Byte 2)
                {0x582A1, 0x1}, //Worms starting energy - Minimum
                {0x5820D, 0x7F}, //Land Sink Rate
                {0x5820F, 0xFF}, //Land Sink Rate - Minimum
                {0x580EC, 0x12}, //Auto Replay Kills
                {0x58113, 0xFF}, //Auto Replay Damage (Byte 1)
                {0x58114, 0xFF}, //Auto Replay Damage (Byte 2)
                {0x58084, 0x7F}, //Wind Strength

                //Weapons
                {0x1170B8, 0xFF}, //Stock
                {0x1170C4, 0xFF}, //Weapon delay
                {0x1170D0, 0xFF}, //Retreat time
                {0x1170DC, 0xFF}, //Total ammo in a crate
                {0x1170E8, 0xFF}, //Bullet count
                {0x1170F4, 0x64}, //Appears in crates (%)
                {0x117100, 0xFF}, //Weapon damage
                {0x11710C, 0xFF}, //Blast power
                {0x117118, 0xFF}, //Explosion bias
                {0x117124, 0xFF}, //Homing delay (milliseconds) (Byte 1)
                {0x117125, 0xFF}, //Homing delay (milliseconds) (Byte 2)
                {0x117130, 0xFF}, //Homing time (milliseconds) (Byte 1)
                {0x117131, 0xFF}, //Homing time (milliseconds) (Byte 2)
                {0x11713C, 0xFF}, //Wind response
                {0x117148, 0xFF}, //No. clusters
                {0x117154, 0xFF}, //Cluster power (Byte 1)
                {0x117155, 0x0}, //Cluster power (Byte 2)
                {0x117160, 0xFF}, //Cluster angle
                {0x11716C, 0xFF}, //Cluster damage
                {0x117178, 0xFF}, //Override fuse
                {0x117184, 0xFF}, //Amount of fire
                {0x117190, 0xFF}, //Fire spread speed
                {0x11719C, 0xFF}, //Fire period
                {0x1171A8, 0xFF}, //Impact force
                {0x1171B4, 0xFF}, //Impact angle
                {0x1171C0, 0xFF}, //Impact damage
                {0x1171CC, 0xFF}, //Jump height
                {0x1171D8, 0xFF}, //Ball damage
                {0x1171E4, 0xFF}, //Power of ball impact
                {0x1171F0, 0xFF}, //Angle of ball impact
                {0x1171FC, 0xFF}, //Time of ball (Byte 1)
                {0x1171FD, 0xFF}, //Time of ball (Byte 2)
                {0x117208, 0xFF}, //Dig time (Byte 1)
                {0x117209, 0xFF}, //Dig time (Byte 2)
                {0x117214, 0xFF}, //Bomblets
                {0x117220, 0xFF}, //Bomb damage
                {0x11722C, 0xFF}, //Bullet spread
            };
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try {
                checkIfPatched();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
                Application.Exit();
            }
            
        }
        private void checkIfPatched()
        {
            using (FileStream fsSource = new FileStream(options.filename, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryReader = new BinaryReader(fsSource)) {
                fsSource.Seek(0x58355, SeekOrigin.Begin);
                ushort result = binaryReader.ReadByte();
                if (result.ToString() == "125") { //Check value of First aid crate
                    options.patched = false;
                    lblStatus.Text = "Frontend is unpatched.";
                    btnPatch.Text = "Patch";
                }
                else {
                    options.patched = true;
                    lblStatus.Text = "Frontend is patched.";
                    btnPatch.Text = "Reverse Patch";
                }
            }
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            Dictionary<long, byte> setOptions = new Dictionary<long, byte> { };
            if (options.patched) {
                setOptions = options.plus;
            }
            else {
                setOptions = options.dev;
            }
            try {
                Stream outStream = File.Open(options.filename, FileMode.Open);
                foreach (KeyValuePair<long, byte> setting in setOptions) {
                    outStream.Seek(setting.Key, SeekOrigin.Begin);
                    outStream.WriteByte(setting.Value);
                }
                outStream.Close();
                checkIfPatched();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error");
            }
        }
    }
}
