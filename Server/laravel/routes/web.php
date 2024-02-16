<?php

use Illuminate\Support\Facades\Route;
use App\Livewire\Counter;
use App\Livewire\Home;
use App\Livewire\ProjectPage;
use App\Livewire\ContactPage;
use App\Livewire\SignInPage;

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

Route::get('/project/{id}', ProjectPage::class);

Route::get('/contact', ContactPage::class);

Route::get('/signin', SignInPage::class);
