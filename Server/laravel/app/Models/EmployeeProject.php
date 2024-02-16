<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasOne;

class EmployeeProject extends Model
{
    use HasFactory;
    use HasUuids;

    const CREATED_AT = 'created_dt';
    const UPDATED_AT = 'updated_at';

    protected $table = 'employee_project';
    protected $primaryKey = 'employee_project_id';

    public $timestamps = false;

    public function project(): BelongsTo
    {
        return $this->belongsTo(Project::class, 'project_id', 'project_id');
    }

    public function employee(): BelongsTo
    {
        return $this->belongsTo(Employee::class, 'employee_id', 'employee_id');
    }
}
