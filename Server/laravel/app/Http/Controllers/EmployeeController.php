<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\View\View;
use App\Models\Employee;

class EmployeeController extends Controller
{
    //
    public function index(): View
    {
        return view('employees.index', Employee::all());
    }

    public function create()
    {
        return View('employees.create');
    }

    public function store(Request $request)
    {
        return view('employees.store');
    }

    public function show($id): View
    {
        return View('employees.show', [
            'employee' => Employee::findOrFail($id)
        ]);
    }

    public function edit($id)
    {
        return View('employees.edit', [
            'employee' => Employee::findOrFail($id)
        ]);
    }

    public function update(Request $request, $id)
    {
    }

    public function destroy($id)
    {
    }
}
