# TvProjectBackend
Async Programming ⚙️<br>
AOP Programming ⚙️ <br>
JWT Token 🔐 <br>
Hashing Password 🔑 <br>
Email Service 📧 <br>
<hr>
Cache and Cache Remove Aspects 🧰 <br>
Performance Aspects 🚀 <br>
Validation Aspects ✔️ <br>
Secure Aspects 🛡️ <br>
<br><br>
Tables📋<br>

Drivers Table <br>
<table>
  <thead>
    <tr>
      <th>Column Name</th>
      <th>Data Type</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>DriverId</td>
      <td>int</td>
    </tr>
    <tr>
      <td>DriverName</td>
      <td>nvarchar(max)</td>
    </tr>
    <tr>
      <td>DriverSurname</td>
      <td>nvarchar(max)</td>
    </tr>
    <tr>
      <td>DriverNumber</td>
      <td>tinyint</td>
    </tr>
    <tr>
      <td>TeamId</td>
      <td>int</td>
    </tr>
    <tr>
      <td>DateOfBirth</td>
      <td>datetime2(7)</td>
    </tr>
    <tr>
      <td>CountryId</td>
      <td>int</td>
    </tr>
    <tr>
      <td>DriverImageUrl</td>
      <td>nvarchar(120)</td>
    </tr>
  </tbody>
</table>
<br>
Teams Table <br>
<table>
  <thead>
    <tr>
      <th>Column Name</th>
      <th>Data Type</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>TeamId</td>
      <td>int</td>
    </tr>
    <tr>
      <td>Name</td>
      <td>nvarchar(30)</td>
    </tr>
    <tr>
      <td>Founder</td>
      <td>nvarchar(50)</td>
    </tr>
    <tr>
      <td>FoundationYear</td>
      <td>datetime2(7)</td>
    </tr>
    <tr>
      <td>TeamBoss</td>
      <td>nvarchar(30)</td>
    </tr>
    <tr>
      <td>TeamImageUrl</td>
      <td>nvarchar(120)</td>
    </tr>
  </tbody>
</table>
