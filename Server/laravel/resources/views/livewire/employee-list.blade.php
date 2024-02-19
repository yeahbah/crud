<div class="table-wrapper">
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Deleted?</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            @foreach ($employees as $employee)
            <tr>
                <td>{{ $employee->first_name }} {{ $employee->last_name }}</td>
                <td>{{ $employee->email }}</td>
                <td>{{ $employee->phone_number }}</td>
                <td>{{ $employee->is_deleted ? 'Y' : 'N' }}</td>
                <td><a class="button" href="/employees/{{ $employee->employee_id }}/edit">Edit</a>
                    <Form method="POST" action="/employees/{{ $employee->employee_id }}">
                        @csrf
                        @method('DELETE')
                        <input type="hidden" value="{{ $employee->employee_id }}">
                        <button>
                            Delete
                        </button>
                    </Form>
                </td>
            </tr>
            @endforeach
        </tbody>

    </table>
</div>