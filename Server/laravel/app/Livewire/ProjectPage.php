<?php

namespace App\Livewire;

use Livewire\Component;
use App\Models\Project;

class ProjectPage extends Component
{

    public Project $project;

    public function mount($id)
    {
        $this->project = Project::findOrFail($id);
    }

    public function render()
    {
        return view('livewire.projectpage');
    }
}
