using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICPartners.DevxUI.UserControls
{
    public class ComboBoxEditSettingsEx : ComboBoxEditSettings
    {
        static ComboBoxEditSettingsEx()
        {
            EditorSettingsProvider.Default.RegisterUserEditor2(typeof(ComboBoxEditEx),
                typeof(ComboBoxEditSettingsEx),
                optimized => optimized ? new InplaceBaseEdit() : (IBaseEdit)new ComboBoxEditEx(), () => new ComboBoxEditSettingsEx());
        }
    }
    public class ComboBoxEditEx : ComboBoxEdit
    {
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (( e.Key == Key.Up || e.Key == Key.Down) && Keyboard.Modifiers == ModifierKeys.None)
            {
                if (e.Key == Key.Up)
                    this.EditStrategy.PerformSpinUp();
                if (e.Key == Key.Down)
                    this.EditStrategy.PerformSpinDown();
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }

        protected override bool NeedsKey(Key key, ModifierKeys modifiers)
        {
            if ((key == Key.Up || key == Key.Down) && modifiers == ModifierKeys.None)
                return true;
            return base.NeedsKey(key, modifiers);
        }
        protected override BaseEditSettings CreateEditorSettings()
        {
            var editSettings = new ComboBoxEditSettingsEx();
            editSettings.ApplyToEdit(this, true, EmptyDefaultEditorViewInfo.Instance);
            return editSettings;
        }


    }

}
