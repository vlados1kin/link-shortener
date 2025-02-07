async function fetchUrls() {
    const response = await fetch('http://localhost:8080/shortener', { method: "GET" });
    
    const json = await response.json();
    
    const urlTableBody = document.getElementById('urlTableBody');
    urlTableBody.innerHTML = '';
    
    json.forEach(item => {
        const urlTableRow = document.createElement('tr');
        urlTableRow.setAttribute("row-id", item.id);
        urlTableRow.innerHTML = `
        <td>${item.longUrl}</td>
        <td><a href="http://localhost:8080/${item.shortUrl}">http://localhost:8080/${item.shortUrl}</a></td>
        <td>${new Date(item.createdAt).toLocaleString()}</td>
        <td>${item.clickCount}</td>
        <td><button class="button delete">Удалить</button></td>
        `;
        urlTableBody.appendChild(urlTableRow);
    });
}

document.addEventListener('DOMContentLoaded', fetchUrls);