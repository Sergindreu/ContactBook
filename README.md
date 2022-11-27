![Deploy_Badge](https://badgen.net/github/stars/Sergindreu/ContactBook)
![Deploy_Badge](https://badgen.net/github/commits/Sergindreu/ContactBook)



# ContactBook

Simple .Net Web App Mvc project where you can create , edit , delete contacts.

## Features 
- Create Contact
- Edit Contact
- Delete Contact



## Tools Used


![alt text](https://github.com/ClosedXML/ClosedXML/raw/develop/resources/logo/readme.png "Logo Title Text 1")

##Export Dtabase Data To Exel 

Here is the example 
```c#
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                            new DataColumn("Name"),
                                            new DataColumn("Email"),
                                            new DataColumn("Phone") });

            var customers = await _service.GetAll();
            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.Id, customer.Name, customer.Email, customer.Phone);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Repo.xlsx");
                }
            }


```
