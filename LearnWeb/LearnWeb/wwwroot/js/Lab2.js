const uri = 'api/Students';
let students = [];

function getStudents() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Unable to get students.', error));
}

function addStudent() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-yearofbirth');

    const student = {
        name: addNameTextbox.value.trim(),
        yearOfBirth: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(response => response.json())
        .then(() => {
            getStudents();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add student.', error));
}

function deleteStudent(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getStudents())
        .catch(error => console.error('Unable to delete student.', error));
}

function displayEditForm(id) {
    const student = students.find(student => student.id === id);

    document.getElementById('edit-id').value = student.id;
    document.getElementById('edit-name').value = student.name;
    document.getElementById('edit-yearofbirth').value = student.yearOfBirth;
    document.getElementById('editForm').style.display = 'block';
}

function updateStudent() {
    const studentId = document.getElementById('edit-id').value;
    const student = {
        id: parseInt(studentId, 10),
        name: document.getElementById('edit-name').value.trim(),
        yearOfBirth: document.getElementById('edit-yearofbirth').value.trim()
    };

    fetch(`${uri}/${studentId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(() => getStudents())
        .catch(error => console.error('Unable to update student.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayStudents(data) {
    const tBody = document.getElementById('students');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(student => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${student.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteStudent(${student.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(student.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(student.yearOfBirth);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    students = data;
}
