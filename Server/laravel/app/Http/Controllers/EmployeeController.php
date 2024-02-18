<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\View;
use Illuminate\Support\Facades\Validator;
use Illuminate\Support\Facades\Redirect;
use Illuminate\Support\Facades\Session;
use App\Models\Employee;
use Illuminate\Http\RedirectResponse;

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
        return View::make('employees.edit')
            ->with('employee', Employee::findOrFail($id));
    }

    public function update(Request $request, $id): RedirectResponse
    {
        $rules = array(
            'first_name' => 'required',
            'last_name' => 'required',
            'birth_date' => 'required|date',
            'email' => 'email'
        );

        $validator = Validator::make($request->all(), $rules);
        if ($validator->fails()) {
            return Redirect::to('/employees/' . $id . '/edit')
                ->withErrors($validator)
                ->withInput();
        }

        $employee = Employee::findOrFail($id);
        $employee->first_name = $request->get('first_name');
        $employee->last_name = $request->get('last_name');
        $employee->email = $request->get('email');
        $employee->phone_number = $request->get('phone_number');

        $employee->save();
        Session::flash('message', 'Successfully updated employee!');
        return Redirect::to('/admin');
    }

    public function destroy($id)
    {
    }
}
