package com.example.exammobiletask;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;

import com.example.exammobiletask.Adapters.GoodsAdapter;
import com.example.exammobiletask.Models.Goods;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class MainActivity extends AppCompatActivity {

    ListView lv_goods;
    Spinner sp_categories;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lv_goods = findViewById(R.id.lv_goods);
        sp_categories = findViewById(R.id.sp_categories);

        InputStream inputStream = getResources().openRawResource(R.raw.goods_category);
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

        int ctr;
        try {
            ctr = inputStream.read();
            while (ctr != -1) {
                byteArrayOutputStream.write(ctr);
                ctr = inputStream.read();
            }
            inputStream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        Log.v("Text Data", byteArrayOutputStream.toString());
        try {
            JSONArray jArray = new JSONArray(
                    byteArrayOutputStream.toString());
            String id = "";
            String name = "";
            String category = "";
            int price = 0;
            ArrayList<Goods> goods = new ArrayList<Goods>();
            ArrayList<String> categories = new ArrayList<>();
            for (int i = 0; i < jArray.length(); i++) {
                id = jArray.getJSONObject(i).getString("IdGoods");
                name = jArray.getJSONObject(i).getString("Name");
                price = jArray.getJSONObject(i).getInt("Price");
                category = jArray.getJSONObject(i).getString("Category");
                goods.add(new Goods(Integer.parseInt(id), name, category,price ));
                if(!categories.contains(category))
                    categories.add(category);
            }

            ArrayAdapter<String> spinnerAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,categories);
            spinnerAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);


            sp_categories.setAdapter(spinnerAdapter);

            AdapterView.OnItemSelectedListener itemSelectedListener = new AdapterView.OnItemSelectedListener() {
                @Override
                public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                    // Получаем выбранный объект
                    String item = (String)parent.getItemAtPosition(position);
                    ArrayList<Goods> category_goods = new ArrayList<Goods>();
                    goods.forEach(goods ->{
                        if (goods.getCategory().equals(item)){
                            category_goods.add(goods);
                        }
                    });
                    GoodsAdapter adapter = new GoodsAdapter(getApplicationContext(), R.layout.item_of_list,category_goods);
                    lv_goods.setAdapter(adapter);
                }

                @Override
                public void onNothingSelected(AdapterView<?> parent) {
                }
            };
            sp_categories.setOnItemSelectedListener(itemSelectedListener);



        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}