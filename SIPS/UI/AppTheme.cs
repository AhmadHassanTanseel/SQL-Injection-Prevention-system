using System.Drawing;
using System.Windows.Forms;

namespace SIPS.UI
{
    internal static class AppTheme
    {
        // ── Night Sidebar ────────────────────────────────────────────────
        private static readonly Color NightBase  = Color.FromArgb(12,  17,  26);
        private static readonly Color NightLayer = Color.FromArgb(20,  27,  39);
        private static readonly Color NightHover = Color.FromArgb(29,  39,  56);
        private static readonly Color NightPress = Color.FromArgb(38,  50,  69);
        private static readonly Color NightText  = Color.FromArgb(195, 208, 226);
        private static readonly Color NightMuted = Color.FromArgb(138, 151, 171);

        // ── Cerulean Primary ────────────────────────────────────────────
        private static readonly Color Cerulean      = Color.FromArgb(47,  128, 237);
        private static readonly Color CeruleanDeep  = Color.FromArgb(26,  108, 212);
        private static readonly Color CeruleanTint  = Color.FromArgb(235, 243, 255);
        private static readonly Color CeruleanPress = Color.FromArgb(20,   90, 180);

        // ── Crimson Danger ──────────────────────────────────────────────
        private static readonly Color Crimson     = Color.FromArgb(229,  62,  74);
        private static readonly Color CrimsonDeep = Color.FromArgb(196,  45,  56);

        // ── Ghost Secondary ─────────────────────────────────────────────
        private static readonly Color GhostBg    = Color.FromArgb(237, 240, 247);
        private static readonly Color GhostText  = Color.FromArgb(55,   72, 105);
        private static readonly Color GhostHover = Color.FromArgb(221, 226, 239);

        // ── Surfaces & Layout ───────────────────────────────────────────
        private static readonly Color Background    = Color.FromArgb(242, 244, 248);
        private static readonly Color Surface       = Color.White;
        private static readonly Color SurfaceStripe = Color.FromArgb(250, 251, 253);
        private static readonly Color BorderLight   = Color.FromArgb(225, 230, 238);
        private static readonly Color BorderMid     = Color.FromArgb(200, 208, 220);

        // ── Typography ──────────────────────────────────────────────────
        private static readonly Color Ink      = Color.FromArgb(12,  18,  32);
        private static readonly Color InkBody  = Color.FromArgb(26,  35,  54);
        private static readonly Color InkMuted = Color.FromArgb(92, 107, 130);

        // ── Fonts ───────────────────────────────────────────────────────
        private static readonly Font FontBase    = new Font("Segoe UI",        10f, FontStyle.Regular);
        private static readonly Font FontLabel   = new Font("Segoe UI",         9f, FontStyle.Regular);
        private static readonly Font FontStrong  = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        private static readonly Font FontMono    = new Font("Consolas",          9f, FontStyle.Regular);


        // ════════════════════════════════════════════════════════════════
        //  Entry point
        // ════════════════════════════════════════════════════════════════

        public static void ApplyToForm(Form form)
        {
            form.BackColor        = Background;
            form.Font             = FontBase;
            form.ForeColor        = InkBody;
            form.StartPosition    = FormStartPosition.CenterScreen;
            form.FormBorderStyle  = FormBorderStyle.FixedSingle;
            form.MaximizeBox      = false;

            WalkControls(form.Controls);
        }


        // ════════════════════════════════════════════════════════════════
        //  Recursive walker
        // ════════════════════════════════════════════════════════════════

        private static void WalkControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                switch (c)
                {
                    case TabPage tp: tp.BackColor = Background; break;  // ← must come BEFORE Panel
                    case Panel p: StylePanel(p); break;
                    case GroupBox gb: StyleGroupBox(gb); break;
                    case Button b: StyleButton(b); break;
                    case TextBox tb: StyleTextBox(tb); break;
                    case RichTextBox rt: StyleRichText(rt); break;
                    case ComboBox cb: StyleComboBox(cb); break;
                    case Label l: StyleLabel(l); break;
                    case CheckBox ch: StyleCheckBox(ch); break;
                    case DataGridView dg: StyleGrid(dg); break;
                }

                if (c.HasChildren) WalkControls(c.Controls);
            }
        }


        // ════════════════════════════════════════════════════════════════
        //  Individual controls
        // ════════════════════════════════════════════════════════════════

        private static void StylePanel(Panel panel)
        {
            bool isSidebar = panel.Dock == DockStyle.Left;

            panel.BackColor = isSidebar ? NightBase : Surface;

            if (isSidebar)
                panel.Padding = new Padding(10, 14, 10, 14);
        }

        private static void StyleGroupBox(GroupBox box)
        {
            box.BackColor  = Surface;
            box.ForeColor  = InkMuted;
            box.Font       = FontLabel;
        }

        private static void StyleLabel(Label label)
        {
            bool isHeading = label.Font.Bold
                          || label.Font.Underline
                          || label.Font.Size >= 13;

            label.ForeColor = isHeading ? Ink : InkMuted;
            label.Font      = isHeading ? new Font("Segoe UI Semibold", label.Font.Size, FontStyle.Bold)
                                        : FontLabel;
        }

        private static void StyleTextBox(TextBox tb)
        {
            tb.BackColor   = Surface;
            tb.ForeColor   = InkBody;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font        = FontBase;

            tb.Enter += (s, _) => ((TextBox)s!).BackColor = CeruleanTint;
            tb.Leave += (s, _) => ((TextBox)s!).BackColor = Surface;
        }

        private static void StyleRichText(RichTextBox rt)
        {
            rt.BackColor   = Surface;
            rt.ForeColor   = InkBody;
            rt.BorderStyle = BorderStyle.FixedSingle;
            rt.Font        = FontBase;
        }

        private static void StyleComboBox(ComboBox cb)
        {
            cb.BackColor      = Surface;
            cb.ForeColor      = InkBody;
            cb.FlatStyle      = FlatStyle.Flat;
            cb.Font           = FontBase;
        }

        private static void StyleCheckBox(CheckBox ch)
        {
            ch.ForeColor = InkBody;
            ch.Font      = FontBase;
            ch.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = FontStrong;

            // ↓ replace the old Padding line with these two
            btn.Height = 40;
            btn.Padding = new Padding(10, 0, 10, 0);


            bool onSidebar = btn.Parent is Panel p && p.Dock == DockStyle.Left;

            bool isDanger  = ContainsAny(btn.Text, "Delete", "Remove", "Cancel", "Logout");
            bool isGhost   = ContainsAny(btn.Text, "Back", "Register", "Close", "Skip");

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor  = Cursors.Hand;
            btn.Font    = FontStrong;
            btn.Padding = new Padding(10, 4, 10, 4);

            if (onSidebar)
            {
                btn.BackColor  = NightLayer;
                btn.ForeColor  = NightText;
                btn.TextAlign  = ContentAlignment.MiddleLeft;
                btn.FlatAppearance.MouseOverBackColor  = NightHover;
                btn.FlatAppearance.MouseDownBackColor  = NightPress;
            }
            else if (isDanger)
            {
                btn.BackColor  = Crimson;
                btn.ForeColor  = Color.White;
                btn.FlatAppearance.MouseOverBackColor  = CrimsonDeep;
                btn.FlatAppearance.MouseDownBackColor  = Color.FromArgb(168, 22, 32);
            }
            else if (isGhost)
            {
                btn.BackColor  = GhostBg;
                btn.ForeColor  = GhostText;
                btn.FlatAppearance.MouseOverBackColor  = GhostHover;
                btn.FlatAppearance.MouseDownBackColor  = BorderLight;
            }
            else
            {
                btn.BackColor  = Cerulean;
                btn.ForeColor  = Color.White;
                btn.FlatAppearance.MouseOverBackColor  = CeruleanDeep;
                btn.FlatAppearance.MouseDownBackColor  = CeruleanPress;
            }
        }

        private static void StyleGrid(DataGridView grid)
        {
            // Layout
            grid.BackgroundColor         = Surface;
            grid.BorderStyle             = BorderStyle.None;
            grid.CellBorderStyle         = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.GridColor               = BorderLight;
            grid.RowHeadersVisible       = false;
            grid.AllowUserToResizeRows   = false;
            grid.SelectionMode           = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect             = false;
            grid.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EnableHeadersVisualStyles = false;

            // Column headers — deep ink band
            var head = grid.ColumnHeadersDefaultCellStyle;
            head.BackColor        = Ink;
            head.ForeColor        = Color.White;
            head.Font             = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            head.SelectionBackColor = Ink;
            head.Padding          = new Padding(8, 0, 8, 0);

            // Default rows
            var row = grid.DefaultCellStyle;
            row.BackColor         = Surface;
            row.ForeColor         = InkBody;
            row.SelectionBackColor = CeruleanTint;
            row.SelectionForeColor = CeruleanDeep;
            row.Font              = FontBase;
            row.Padding           = new Padding(6, 0, 6, 0);

            // Alternating rows — barely-there stripe
            grid.AlternatingRowsDefaultCellStyle.BackColor = SurfaceStripe;

            // Row height
            grid.ColumnHeadersHeight     = 36;
            grid.RowTemplate.Height      = 34;
        }


        // ════════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════════

        private static bool ContainsAny(string source, params string[] words)
        {
            foreach (var word in words)
                if (source.Contains(word, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }
    }
}