<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Database\Eloquent\Model;

class Employee extends Model
{
    use HasFactory;
    use HasUuids;

    protected $table = 'employee';
    protected $primaryKey = 'employee_id';

    public $timestamps = false;

    public function testimonials(): HasMany
    {
        return $this->hasMany(EmployeeTestimonial::class, 'employee_id', 'employee_id');
    }

    public function projects(): HasMany
    {
        return $this->hasMany(EmployeeProject::class, 'employee_id', 'employee_id');
    }
}
