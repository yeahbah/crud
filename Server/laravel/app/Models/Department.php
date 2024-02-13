<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Concerns\HasUuids;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Department extends Model
{
    use HasFactory;
    use HasUuids;

    const CREATED_AT = 'created_dt';
    const UPDATED_AT = 'updated_dt';

    protected $table = 'deparment';
    protected $primaryKey = 'deparment_id';

    public $timestamps = false;
}
