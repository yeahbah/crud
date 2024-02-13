<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Ramsey\Uuid\Uuid;

class EmployeeSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        //
        DB::table('employee')->insert([
            'employee_id' => '05a50b8b-8f72-4999-a786-a3b64c830bc8',
            'birth_date' => '1972-3-14',
            'department_code' => 'SUP',
            'first_name' => 'System',
            'last_name' => 'System'
        ]);

        DB::table('employee')->insert([
            'employee_id' => Uuid::uuid4(),
            'birth_date' => '1972-3-14',
            'department_code' => 'BOARD',
            'first_name' => 'Fellon',
            'last_name' => 'Mask',
            'email' => 'mars@spacey.com',
            'phone_number' => '1112223333'
        ]);
        DB::table('employee')->insert([
            'employee_id' => Uuid::uuid4(),
            'birth_date' => '1972-3-14',
            'department_code' => 'BOARD',
            'first_name' => 'Bill',
            'last_name' => 'Geyts',
            'email' => 'bill.cool@spacey.com',
            'phone_number' => '2223334567'
        ]);
        DB::table('employee')->insert([
            'employee_id' => Uuid::uuid4(),
            'birth_date' => '1980-04-1',
            'department_code' => 'ENG',
            'first_name' => 'Bus',
            'last_name' => 'Lightmonth',
            'email' => 'toinfinityandbeyond@spacey.com',
            'phone_number' => '3334445555'
        ]);
        DB::table('employee')->insert([
            'employee_id' => Uuid::uuid4(),
            'birth_date' => '1985-01-02',
            'department_code' => 'RKT',
            'first_name' => 'Robert',
            'last_name' => 'Goddard',
            'email' => 'iloverockets@spacey.com'
        ]);
        DB::table('employee')->insert([
            'employee_id' => Uuid::uuid4(),
            'birth_date' => '1970-05-09',
            'department_code' => 'LOG',
            'first_name' => 'Heff',
            'last_name' => 'Bezoos',
            'email' => 'mynameheff@spacey.com'
        ]);
    }
}
