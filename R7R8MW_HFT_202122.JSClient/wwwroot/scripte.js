let actors = [];
let connection = null;

let actorIdToUpdate = -1;

getdata();
setupSignalR();

fetch('http://localhost:60038/actor')
    .then(x => x.json())
    .then(y => { actors = y; display(); });

async function getdata() {
    await fetch('http://localhost:60038/actor')
        .then(x => x.json())
        .then(y => {
            actors = y;
            //console.log(actors);
            display();
        });
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60038/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
        getdata();
    });

    connection.on("ActorUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

function display() {
    document.getElementById('resultArea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.id})">Update</button>` 
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('updateformdiv').style.display = 'flex';
    document.getElementById('actornametoupdate').value = actors.find(t => t['id'] == id)['name'];

    actorIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('actornametoupdate').value;

    fetch('http://localhost:60038/actor', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Id:actorIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function remove(id) {
    fetch('http://localhost:60038/actor/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('actorname').value;
    fetch('http://localhost:60038/actor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}