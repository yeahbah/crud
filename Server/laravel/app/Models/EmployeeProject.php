<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class EmployeeProject extends Model
{
    use HasFactory;
    use HasUuids;

    const CREATED_AT = 'created_dt';
    const UPDATED_AT = 'updated_at';

    protected $table = 'employee_project';
    protected $primaryKey = 'employee_project_id';

    public $timestamps = false;
}
