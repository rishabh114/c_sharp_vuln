using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

class Bad
{
    public static object Deserialize(TextBox textBox)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
        // BAD
        return serializer.DeserializeObject(textBox.Text);
    }
}
