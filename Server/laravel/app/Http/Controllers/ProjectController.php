<?php

namespace App\Http\Controllers;

use App\Models\Project;
use Illuminate\Http\RedirectResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\View;

class ProjectController extends Controller
{
    //
    function index(): View
    {
        return View('projects.index', Project::all());
    }

    function show($id): View
    {
        return View('projects.show', Project::findOrFail($id));
    }

    function store(Request $request): RedirectResponse
    {
    }

    function create()
    {
        return View('projects.create');
    }

    function edit($id)
    {
        return View('projects.edit', Project::findOrFail($id));
    }

    function update(Request $request, $id): RedirectResponse
    {
    }

    function destroy($id)
    {
    }
}
