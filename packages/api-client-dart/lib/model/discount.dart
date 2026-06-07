//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/discount_type.dart';
import 'package:mansis_pos_api_client/model/discount_category.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'discount.g.dart';

abstract class Discount implements Built<Discount, DiscountBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    @BuiltValueField(wireName: r'maxDiscountAmount')
    double get maxDiscountAmount;

    @nullable
    @BuiltValueField(wireName: r'monthlyLimit')
    double get monthlyLimit;

    @nullable
    @BuiltValueField(wireName: r'expireDate')
    DateTime get expireDate;

    @BuiltValueField(wireName: r'discountType')
    DiscountType get discountType;
    // enum discountTypeEnum {  Percentage,  Amount,  };

    @BuiltValueField(wireName: r'discountCategory')
    DiscountCategory get discountCategory;
    // enum discountCategoryEnum {  All,  Branch,  Personnel,  Pos,  };

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @BuiltValueField(wireName: r'active')
    bool get active;

    @BuiltValueField(wireName: r'branchIds')
    BuiltList<String> get branchIds;

    @BuiltValueField(wireName: r'posIds')
    BuiltList<String> get posIds;

    @BuiltValueField(wireName: r'userIds')
    BuiltList<String> get userIds;

    Discount._();

    static void _initializeBuilder(DiscountBuilder b) => b;

    factory Discount([void updates(DiscountBuilder b)]) = _$Discount;

    @BuiltValueSerializer(custom: true)
    static Serializer<Discount> get serializer => _$DiscountSerializer();
}

class _$DiscountSerializer implements StructuredSerializer<Discount> {

    @override
    final Iterable<Type> types = const [Discount, _$Discount];
    @override
    final String wireName = r'Discount';

    @override
    Iterable<Object> serialize(Serializers serializers, Discount object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        if (object.description != null) {
            result
                ..add(r'description')
                ..add(serializers.serialize(object.description,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        result
            ..add(r'maxDiscountAmount')
            ..add(serializers.serialize(object.maxDiscountAmount,
                specifiedType: const FullType(double)));
        if (object.monthlyLimit != null) {
            result
                ..add(r'monthlyLimit')
                ..add(serializers.serialize(object.monthlyLimit,
                    specifiedType: const FullType(double)));
        }
        if (object.expireDate != null) {
            result
                ..add(r'expireDate')
                ..add(serializers.serialize(object.expireDate,
                    specifiedType: const FullType(DateTime)));
        }
        result
            ..add(r'discountType')
            ..add(serializers.serialize(object.discountType,
                specifiedType: const FullType(DiscountType)));
        result
            ..add(r'discountCategory')
            ..add(serializers.serialize(object.discountCategory,
                specifiedType: const FullType(DiscountCategory)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        result
            ..add(r'branchIds')
            ..add(serializers.serialize(object.branchIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        result
            ..add(r'posIds')
            ..add(serializers.serialize(object.posIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        result
            ..add(r'userIds')
            ..add(serializers.serialize(object.userIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    Discount deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = DiscountBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'maxDiscountAmount':
                    result.maxDiscountAmount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'monthlyLimit':
                    result.monthlyLimit = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'expireDate':
                    result.expireDate = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'discountType':
                    result.discountType = serializers.deserialize(value,
                        specifiedType: const FullType(DiscountType)) as DiscountType;
                    break;
                case r'discountCategory':
                    result.discountCategory = serializers.deserialize(value,
                        specifiedType: const FullType(DiscountCategory)) as DiscountCategory;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'branchIds':
                    result.branchIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
                case r'posIds':
                    result.posIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
                case r'userIds':
                    result.userIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

