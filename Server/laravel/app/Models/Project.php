<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Project extends Model
{
    use HasFactory;
    use HasUuids;

    const CREATED_AT = 'created_dt';
    const UPDATED_AT = 'updated_dt';

    protected $table = 'project';
    protected $primaryKey = 'project_id';

    public $timestamps = false;

    function employees(): HasMany
    {
        return $this->hasMany(EmployeeProject::class, 'project_id', 'project_id');
    }
}
