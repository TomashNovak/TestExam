package com.example.exammobiletask.Adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.exammobiletask.Models.Goods;
import com.example.exammobiletask.R;

import java.util.List;

public class GoodsAdapter extends ArrayAdapter<Goods> {

    private LayoutInflater inflater;
    private int layout;
    private List<Goods> goods;

    public GoodsAdapter(Context context, int resource, List<Goods> goods) {
        super(context,resource, goods);
        this.goods = goods;
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
    }
    public View getView(int position, View convertView, ViewGroup parent) {

        View view=inflater.inflate(this.layout, parent, false);

        TextView tv_name = view.findViewById(R.id.tv_name);
        TextView tv_category = view.findViewById(R.id.tv_category);
        TextView tv_price = view.findViewById(R.id.tv_price);

        Goods state = goods.get(position);

        tv_name.setText(state.getName());
        tv_category.setText(state.getCategory());
        tv_price.setText(String.valueOf(state.getPrice()));

        return view;
    }
}
