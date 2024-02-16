<?php

namespace App\Livewire;

use Livewire\Component;
use Livewire\Attributes\Title;
use App\Models\Project;

#[Title('It\'s a Crud Life')]
class Home extends Component
{
    public $title = 'This is the crud life';

    public $projects;

    public function render()
    {
        $this->projects = Project::all();
        return view('livewire.home');
    }
}
