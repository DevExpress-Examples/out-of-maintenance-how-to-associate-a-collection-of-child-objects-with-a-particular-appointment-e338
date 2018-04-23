# How to associate a collection of child objects with a particular appointment


<p>This scenario might be useful if you want to associate some collection of data objects with an appointment. Basic <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument5228"><u>Custom Fields</u></a> does not provide the capability to implement this scenario. They provide only the capability to store scalar data values (e.g. integer value, string value, etc.). However, you can use a Custom Field of the string type and store a collection in an XML format. Use the <a href="http://www.switchonthecode.com/tutorials/csharp-tutorial-xml-serialization"><u>XMLSerializer</u></a> object to serialize/deserialize a collection (see Invoices and SourceInvoices CustomAppointmentFormController class properties implementation).</p><p>Alternatively, you can use a separate table in your database to store child objects of an appointment. They can be retrieved via specific TableAdapter methods (PetsTableAdapter.FillBy() method in this example).</p><p>Both approaches have been illustrated in this example. Moreover, you can edit the corresponding collections in the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument2288"><u>Custom EditAppointment Form</u></a> via DataGridViews.</p>

<br/>


