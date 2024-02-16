<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class EmployeeTestimonial extends Model
{
    use HasFactory;
    use HasUuids;

    protected $table = 'employee_testimonial';
    protected $primaryKey = 'employee_testimonial_id';

    public $timestamps = false;

    function employee(): BelongsTo
    {
        return $this->belongsTo(Employee::class, 'employee_id', 'employee_id');
    }
}
