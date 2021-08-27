<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633703/16.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3380)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomAppointmentForm.cs](./CS/CustomAppointmentForm.cs) (VB: [CustomAppointmentForm.vb](./VB/CustomAppointmentForm.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Invoice.cs](./CS/Invoice.cs) (VB: [Invoice.vb](./VB/Invoice.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to associate a collection of child objects with a particular appointment


<p>This scenario might be useful if you want to associate some collection of data objects with an appointment. Basic <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument5228"><u>Custom Fields</u></a> does not provide the capability to implement this scenario. They provide only the capability to store scalar data values (e.g. integer value, string value, etc.). However, you can use a Custom Field of the string type and store a collection in an XML format. Use the <a href="https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=net-5.0"><u>XMLSerializer</u></a> object to serialize/deserialize a collection (see Invoices and SourceInvoices CustomAppointmentFormController class properties implementation).</p><p>Alternatively, you can use a separate table in your database to store child objects of an appointment. They can be retrieved via specific TableAdapter methods (PetsTableAdapter.FillBy() method in this example).</p><p>Both approaches have been illustrated in this example. Moreover, you can edit the corresponding collections in the <a href="https://supportcenter.devexpress.com/ticket/details/a2920/how-to-customize-the-edit-appointment-form-to-show-custom-fields"><u>Custom EditAppointment Form</u></a> via DataGridViews.</p>

<br/>


