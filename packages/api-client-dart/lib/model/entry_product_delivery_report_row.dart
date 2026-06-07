//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'entry_product_delivery_report_row.g.dart';

abstract class EntryProductDeliveryReportRow implements Built<EntryProductDeliveryReportRow, EntryProductDeliveryReportRowBuilder> {

    @BuiltValueField(wireName: r'date')
    DateTime get date;

    @BuiltValueField(wireName: r'branchId')
    String get branchId;

    @BuiltValueField(wireName: r'branchName')
    String get branchName;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @BuiltValueField(wireName: r'posName')
    String get posName;

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'productName')
    String get productName;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    EntryProductDeliveryReportRow._();

    static void _initializeBuilder(EntryProductDeliveryReportRowBuilder b) => b;

    factory EntryProductDeliveryReportRow([void updates(EntryProductDeliveryReportRowBuilder b)]) = _$EntryProductDeliveryReportRow;

    @BuiltValueSerializer(custom: true)
    static Serializer<EntryProductDeliveryReportRow> get serializer => _$EntryProductDeliveryReportRowSerializer();
}

class _$EntryProductDeliveryReportRowSerializer implements StructuredSerializer<EntryProductDeliveryReportRow> {

    @override
    final Iterable<Type> types = const [EntryProductDeliveryReportRow, _$EntryProductDeliveryReportRow];
    @override
    final String wireName = r'EntryProductDeliveryReportRow';

    @override
    Iterable<Object> serialize(Serializers serializers, EntryProductDeliveryReportRow object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'date')
            ..add(serializers.serialize(object.date,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'branchId')
            ..add(serializers.serialize(object.branchId,
                specifiedType: const FullType(String)));
        result
            ..add(r'branchName')
            ..add(serializers.serialize(object.branchName,
                specifiedType: const FullType(String)));
        result
            ..add(r'posId')
            ..add(serializers.serialize(object.posId,
                specifiedType: const FullType(String)));
        result
            ..add(r'posName')
            ..add(serializers.serialize(object.posName,
                specifiedType: const FullType(String)));
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'productName')
            ..add(serializers.serialize(object.productName,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    EntryProductDeliveryReportRow deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = EntryProductDeliveryReportRowBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'date':
                    result.date = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'branchId':
                    result.branchId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'branchName':
                    result.branchName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'posId':
                    result.posId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'posName':
                    result.posName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productName':
                    result.productName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

