<?php

namespace App\Livewire;

use Livewire\Component;
use Livewire\Attributes\Title;

#[Title('It\'s a Crud Life')]
class Home extends Component
{
    public $title = 'This is the crud life';

    public function render()
    {
        return view('livewire.home');
    }
}
