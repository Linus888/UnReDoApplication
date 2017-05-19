using System.Windows;
using System.Windows.Controls;
using WpfApplication3.ViewModel;

namespace WpfApplication3.View
{
    class CommandTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AddCommandTemplate { get; set; }
        public DataTemplate RemoveCommandTemplate { get; set; }
        public DataTemplate DefaulTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AddCommand)
            {
                return AddCommandTemplate;
            }
            if (item is DeleteCommand)
            {
                return RemoveCommandTemplate;
            }
            else
            {
                return DefaulTemplate;
            }
        }
    }
}
