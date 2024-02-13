<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Ramsey\Uuid\Uuid;

class DepartmentSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        //
        DB::table('department')->insert([
            'department_code' => 'IT',
            'name' => 'Information Technology',
            'is_deleted' => 0,
        ]);

        DB::table('department')->insert([
            'department_code' => 'LOG',
            'name' => 'Logistics',
            'is_deleted' => 0
        ]);

        DB::table('department')->insert([
            'department_code' => 'ENG',
            'name' => 'Engineering',
            'is_deleted' => 0
        ]);

        DB::table('department')->insert([
            'department_code' => 'SUP',
            'name' => 'Tech Support',
            'is_deleted' => 0
        ]);

        DB::table('department')->insert([
            'department_code' => 'RKT',
            'name' => 'Rockets',
            'is_deleted' => 0
        ]);

        DB::table('department')->insert([
            'department_code' => 'BOARD',
            'name' => 'Leadership',
            'is_deleted' => 0
        ]);
    }
}
