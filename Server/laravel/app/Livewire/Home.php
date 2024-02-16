<?php

namespace App\Livewire;

use App\Models\Employee;
use Livewire\Component;
use Livewire\Attributes\Title;
use App\Models\Project;

#[Title('It\'s a Crud Life')]
class Home extends Component
{
    public $title = 'This is the crud life';

    public $projects;
    public $employees;

    public function render()
    {
        $this->projects = Project::all();
        $this->employees = Employee::where('first_name', '!=', 'System')->get();
        return view('livewire.home');
    }
}
