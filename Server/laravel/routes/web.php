<?php

use App\Http\Controllers\EmployeeController;
use App\Http\Controllers\ProjectController;
use Illuminate\Support\Facades\Route;
use App\Livewire\Counter;
use App\Livewire\Home;
use App\Livewire\ProjectPage;
use App\Livewire\ContactPage;
use App\Livewire\SignInPage;
use App\Livewire\AdminPage;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

Route::get('/', Home::class);

Route::get('/counter', Counter::class);

// Route::get('/projects/{id}', ProjectPage::class);

Route::resource('projects', ProjectController::class);

Route::resource('employees', EmployeeController::class);

Route::get('/contact', ContactPage::class);

Route::get('/signin', SignInPage::class);

Route::get('/admin', AdminPage::class);
