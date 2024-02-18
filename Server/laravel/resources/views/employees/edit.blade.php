<div>
    <div style="background-color: #000; height: 100px;"> </div>

    <!-- <section class="wrapper style1"> -->
    <div class="inner" style="margin: 50px;">

        <!-- {{ $employee }} -->

        <form method="POST" action="/employees/{{ $employee->employee_id }}">
            @csrf
            @method('PUT')


            <label for="first_name">First Name</label>
            <input type="text" value="{{$employee->first_name}}" id="first_name" name="first_name">
            @error('first_name')
            <div class="alert alert-danger">{{ $message }}</div>
            @enderror

            <label for="last_name">Last Name</label>
            <input type="text" value="{{ $employee->last_name }}" id="last_name" name="last_name">
            @error('last_name')
            <div class="alert alert-danger">{{ $message }}</div>
            @enderror

            <label for="email">Email</label>
            <input type="text" value="{{ $employee->email }}" id="email" name="email">
            @error('email')
            <div class="alert alert-danger">{{ $message }}</div>
            @enderror

            <label for="phone_number">Phone Number</label>
            <input type="text" value="{{ $employee->phone_number }}" id="phone_number" name="phone_number">
            @error('phone_number')
            <div class="alert alert-danger">{{ $message }}</div>
            @enderror
            <input type="text" value="{{ $employee->birth_date }}" id="birth_date" name="birth_date">
            @error('birth_date')
            <div class="alert alert-danger">{{ $message }}</div>
            @enderror

            <button type="submit">Save</button>

            <button onclick="history.back();">Cancel</button>
        </form>


    </div>
</div>