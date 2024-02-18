<?php

namespace App\Livewire;

use Livewire\Component;
use App\Models\Employee;

class EmployeeList extends Component
{
    public $employees;

    public function render()
    {
        $this->employees = Employee::all();
        return view('livewire.employee-list');
    }
}
